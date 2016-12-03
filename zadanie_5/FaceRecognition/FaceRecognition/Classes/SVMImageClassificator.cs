#region Zdroje
//  https://searchcode.com/codesearch/view/13630465/
//  http://www.heatonresearch.com/content/encog_svm_multiclass.html
//  Encog3CS-User.pdf
#endregion

#region Include
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Encog.ML.SVM;
using Encog.ML.Train;
using Encog.ML.SVM.Training;
using Encog.ML.Data;
using Encog.ML.Data.Basic;
using Encog.ML.Data.Image;
using Encog.Util.DownSample;
#endregion


namespace FaceRecognition.Classes
{
    class SVMImageClassificator
    {
        int downsampleFactor = 1;
        int downsampledWidth;
        int downsampledHeight;
        int inputNeuronsCount;

        System.Windows.Forms.RichTextBox richTextBox;

        SimpleIntensityDownsample simpleDownsample;
        ImageMLDataSet trainingImageData;
        ImageMLDataSet testImageData;

        SupportVectorMachine svmNetwork;

        public SVMImageClassificator(System.Windows.Forms.RichTextBox richTextBox)
        {
            this.richTextBox = richTextBox;
            downsampledWidth = 92 / downsampleFactor;
            downsampledHeight = 112 / downsampleFactor;
            //  * 3 preto, pretoze SimpleIntensityDownsample nefunguje tak ako je popisane v manualy,
            //  nevracia iba intenzitu na pixel, ale rgb zlozky na pixel
            inputNeuronsCount = downsampledWidth * downsampledHeight * 3;

            CreateDataSets();
            TrainNetwork();
        }

        private void CreateDataSets()
        {
            WriteInformation("Creating datasets...", Color.Black);
            simpleDownsample = new SimpleIntensityDownsample();
            //  sposob downsamplu, bool findBounds, range na ktory sa normalizuju data
            trainingImageData = new ImageMLDataSet(simpleDownsample, false, 1, 0);
            testImageData = new ImageMLDataSet(simpleDownsample, false, 1, 0);

            for (int faceNumber = 1; faceNumber <= 40; faceNumber++)
            {
                for (int imageNumber = 1; imageNumber <= 10; imageNumber++)
                {
                    if (imageNumber <= 7)
                    {
                        var data = new ImageMLData(ImageLoader.GetImage(faceNumber, imageNumber));
                        IMLData ideal = new BasicMLData(new double[] { faceNumber });
                        trainingImageData.Add(data, ideal);
                    }
                    else
                    {
                        var data = new ImageMLData(ImageLoader.GetImage(faceNumber, imageNumber));
                        IMLData ideal = new BasicMLData(new double[] { faceNumber });
                        testImageData.Add(data, ideal);
                    }
                }                
            }

            //  Once all of the images are loaded, they are ready to be downsampled
            //  v tomto pripade je velkost downsamplovaneho obrazka rovnaka ako povodneho
            trainingImageData.Downsample(downsampledHeight, downsampledWidth);
            testImageData.Downsample(downsampledHeight, downsampledWidth);

            WriteInformation("Datasets created succesfully!", Color.Black);
        }

        private SupportVectorMachine CreateNetwork()
        {
            //return new SupportVectorMachine(inputNeuronsCount, SVMType.SupportVectorClassification, KernelType.RadialBasisFunction);  //  72 matches pri /4
            //return new SupportVectorMachine(inputNeuronsCount, SVMType.SupportVectorClassification, KernelType.Linear);   //  96 matches pri /4
            //return new SupportVectorMachine(inputNeuronsCount, SVMType.SupportVectorClassification, KernelType.Poly);   // 94 matches pri /4
            //return new SupportVectorMachine(inputNeuronsCount, SVMType.SupportVectorClassification, KernelType.Linear);   //  106 matches pri /2
            //return new SupportVectorMachine(inputNeuronsCount, SVMType.SupportVectorClassification, KernelType.Poly);   // 105 matches pri /4
            return new SupportVectorMachine(inputNeuronsCount, SVMType.SupportVectorClassification, KernelType.Linear);   // 116 matches pri /1
            //return new SupportVectorMachine(inputNeuronsCount, SVMType.SupportVectorClassification, KernelType.Poly);   // 115 matches pri /1
            
        }

        private void TrainNetwork()
        {
            WriteInformation("Creating SVM network...", Color.Black);
            svmNetwork = CreateNetwork();
            WriteInformation("SVM network created succesfully!", Color.Black);

            WriteInformation("Training SVM network...", Color.Black);
            IMLTrain train = new SVMSearchTrain(svmNetwork, trainingImageData);

            int epoch = 1;
            do
            {
                train.Iteration();
                System.Diagnostics.Debug.WriteLine(@"Epoch #" + epoch + @" Error:" + train.Error);
                epoch++;
            } while (train.Error > 0.01);

            WriteInformation("Training succesfully ended!", Color.Black);
        }

        private void WriteInformation(string information, Color color)
        {
            int length = richTextBox.TextLength;  // at end of text
            richTextBox.AppendText(information + "\n");
            richTextBox.SelectionStart = length;
            richTextBox.SelectionLength = information.Length + 1;
            richTextBox.SelectionColor = color;
            richTextBox.Refresh();
        }

        public void TestNetwork()
        {
            richTextBox.Clear();
            int matchesCount = 0;
            int nonMatchsCount = 0;
            WriteInformation("Testing SVM network...", Color.Black);
            foreach (var pair in testImageData)
            {
                IMLData output = svmNetwork.Compute(pair.Input);
                if ((output[0] - pair.Ideal[0]) == 0)
                {
                    WriteInformation("actual = " + output[0] + @",  ideal = " + pair.Ideal[0], Color.Green);
                    matchesCount++;
                } 
                else
                {
                    WriteInformation("actual = " + output[0] + @",  ideal = " + pair.Ideal[0], Color.Red);
                    nonMatchsCount++;
                }
            }
            WriteInformation("Testing succesfully ended!", Color.Black);
            WriteInformation("\nMatches: " + matchesCount + "/" + (matchesCount + nonMatchsCount), Color.Black);
            WriteInformation("Succesfull matches: " + 
                Math.Round((100 * (matchesCount / (double)(matchesCount + nonMatchsCount))), 2).ToString() + "%", Color.Black);
        }
    }
}
