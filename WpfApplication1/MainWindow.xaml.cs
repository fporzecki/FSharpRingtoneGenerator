using System;
using System.Windows;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void clearScoreBtn_Click(object sender, RoutedEventArgs e)
        {
            scoreTextBox.Text = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            filenameTextBox.Text = "";
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            var score = scoreTextBox.Text;
            var filename = filenameTextBox.Text;
            try
            {

                ComposerMethods.ComposerMethods.packSounds(score, filename);
                MessageBox.Show("A file " + filename + " was created "
                    + "successfully at your current directory!", "Success!");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("To create your own ringtone type a note score"
                + " into the designated text box, then give it a name.\n"
                + "It's considered good practice for the name to end with .wav"
                + " but if you don't give it this ending, then the program"
                + " will do it for you.", "Help");
        }
    }
}
