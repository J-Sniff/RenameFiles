using System;
using System.IO;

class Program
{
	static void Main()
	{
		// Place file path here
		string folderPath = "Your file path here";

		// Get all files in the folder
		string[] files = Directory.GetFiles(folderPath);

		foreach (string filePath in files)
		{
			// Get the file name without the path
			string fileName = Path.GetFileName(filePath);

			// Find the index of the first underscore
			int firstUnderscoreIndex = fileName.IndexOf('_');

			if (firstUnderscoreIndex != -1 && firstUnderscoreIndex < fileName.Length - 1)
			{
				// Replace underscores after the first one with dashes
				string newFileName = fileName.Substring(0, firstUnderscoreIndex + 1) +
									 fileName.Substring(firstUnderscoreIndex + 1).Replace("_", "-");

				// Combine the new file name with the original path
				string newFilePath = Path.Combine(folderPath, newFileName);

				// Rename the file
				File.Move(filePath, newFilePath);

				Console.WriteLine($"Renamed: {fileName} to {newFileName}");
			}
			else
			{
				Console.WriteLine($"Skipped: {fileName} (no underscores to replace)");
			}
		}

		Console.WriteLine("All files processed successfully.");
		Console.ReadLine();		
	}
}
