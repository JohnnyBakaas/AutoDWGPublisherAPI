using System.Runtime.InteropServices;

namespace AutoDWGPublisherAPI.Model
{
    public class AutoDWGPublisher
    {
        public async Task<string> PublishAllInFolder(string folderPath)
        {
            string DWGPath = $@"{folderPath}\DWG";
            string PDFPath = $@"{folderPath}\PDF";

            if (!Directory.Exists(DWGPath))
            {
                return $"The provided folder path does not exist: {DWGPath}";
            }

            if (!Directory.Exists(PDFPath))
            {
                Directory.CreateDirectory(PDFPath);
            }

            string[] dwgFiles = Directory.GetFiles(DWGPath, "*.dwg");

            if (dwgFiles.Length == 0)
            {
                return $"No DWG files found in the specified folder.";
            }

            int maxRetries = 5;
            int retryDelayMilliseconds = 2000;
            bool success = false;

            for (int retry = 0; retry < maxRetries && !success; retry++)
            {
                try
                {
                    Type acadType = Type.GetTypeFromProgID("AutoCAD.Application.24");
                    dynamic acadApp = Activator.CreateInstance(acadType, true);
                    acadApp.Visible = false;

                    // Close the default drawing (Drawing1)
                    acadApp.ActiveDocument.Close(false);

                    foreach (string dwgFile in dwgFiles)
                    {
                        bool fileProcessed = false;
                        int fileRetry = 0;
                        while (!fileProcessed && fileRetry < maxRetries)
                        {
                            try
                            {
                                dynamic doc = acadApp.Documents.Open(dwgFile, false);

                                string outputFileName = Path.Combine(PDFPath, Path.GetFileNameWithoutExtension(dwgFile) + ".pdf");

                                // Publish the drawing using default settings
                                doc.Plot.PlotToFile(outputFileName, "DWG To PDF.pc3");

                                doc.Close(false);
                                fileProcessed = true;
                            }
                            catch (COMException ex) when (ex.ErrorCode == unchecked((int)0x8001010A))
                            {
                                fileRetry++;
                                await Task.Delay(retryDelayMilliseconds);
                            }
                            catch (Exception ex)
                            {

                                return $"Error processing {dwgFile}: {ex.Message}";
                            }
                        }
                    }

                    acadApp.Quit();
                    success = true;
                }
                catch (COMException ex) when (ex.ErrorCode == unchecked((int)0x8001010A))
                {
                    await Task.Delay(retryDelayMilliseconds);
                }
                catch (COMException ex)
                {
                    return $"Error initializing AutoCAD: {ex.Message}";
                }
                catch (Exception ex)
                {
                    return $"Unexpected error: {ex.Message}";
                }
            }

            if (!success)
            {
                return "Failed to initialize AutoCAD after all retries.";
            }
            return "DWG(s) printed sucsesfully";
        }
    }
}
