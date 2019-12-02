using System;
using Windows.UI.Xaml.Controls;
using Windows.Storage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DemoSimpleFile
{
    /// <summary>
    /// Demonstration of file handling.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Display some text in UI
            output.Text = "Demo file handling. This text is soon replaced.";

            // Run file handling demo.
            // OBS Do not need to await call to Run() because it returns void and not Task<T>
            // OBS Run returns instantly and the page is displayed
            Run();
            // The call to Run() finnishes in the background.
        }
        /// <summary>
        /// source of information: 
        /// https://docs.microsoft.com/en-us/windows/uwp/files/quickstart-reading-and-writing-files
        /// </summary>
        private async void Run()
        {
            // Wait for 2 seconds (2000 milliseconds). Gives user time to read before text changes.
            await System.Threading.Tasks.Task.Delay(2000);

            // Folder to store file in
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

            // Display path in UI
            path.Text = storageFolder.Path;

            // Create file in specified folder, overwrite existing file
            StorageFile sampleFile =
            await storageFolder.CreateFileAsync("sample.txt", CreationCollisionOption.ReplaceExisting);


            // Get file to write to
            StorageFile file = await storageFolder.GetFileAsync("sample.txt");

            // Write message to existing file
            await FileIO.WriteTextAsync(file, "Text to write to file.");

            // Append message to existing file
            await FileIO.AppendTextAsync(file, "Text appended to file.");

            // Read from file
            string textInFile = await FileIO.ReadTextAsync(file);

            // display text in UI
            output.Text = textInFile;
        }
    }
}
