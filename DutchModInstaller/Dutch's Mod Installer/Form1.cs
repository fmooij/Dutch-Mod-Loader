namespace Dutch_s_Mod_Installer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string path = FindRdr2Dir();
            if (!string.IsNullOrEmpty(path))
                textBox1.Text = path;
            else
                MessageBox.Show(
                    "RDR2 folder not found automatically.\nPlease select it manually.",
                    "RDR2 Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
        }

        private string[] GetPartsFromLine(string line)
        {
            // Implementation: Split the line once at the first colon and return the two parts.
            if (!line.Contains(":"))
            {
                // Throw an error via message box and return empty array
                MessageBox.Show(
                    $"Line '{line}' is not in the expected format.",
                    "Invalid Line Format",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return Array.Empty<string>();
            }
            string[] parts = line.Split(new char[] { ':' }, 2);
            return parts;
        }
        private void CopyAll(string sourceDir, string destDir)
        {
            Directory.CreateDirectory(destDir);

            foreach (string dirPath in Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourceDir, destDir));
            }

            foreach (string filePath in Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(filePath, filePath.Replace(sourceDir, destDir), true);
            }
        }

        private string FindRdr2Dir()
        {
            string[] possiblePaths =
            {
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                    "Rockstar Games", "Red Dead Redemption 2"
                ),
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
                    "Rockstar Games", "Red Dead Redemption 2"
                ),
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
                    "Steam", "steamapps", "common", "Red Dead Redemption 2"
                )
            };

            foreach (string path in possiblePaths)
            {
                if (File.Exists(Path.Combine(path, "RDR2.exe")))
                    return path;
            }

            return string.Empty;
        }

        private void Browse_RDR2_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select Red Dead Redemption 2 game folder";

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(Path.Combine(fbd.SelectedPath, "RDR2.exe")))
                        textBox1.Text = fbd.SelectedPath;
                    else
                        MessageBox.Show(
                            "This folder does not contain RDR2.exe",
                            "Invalid Folder",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                }
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            string RDR2Path;
            string DMIConfigPath;

            if (Directory.Exists(textBox1.Text) && File.Exists(textBox2.Text))
            {
                RDR2Path = textBox1.Text;
                DMIConfigPath = textBox2.Text;
            }
            else
            {
                MessageBox.Show(
                    "Please ensure both paths are valid before starting the installation.",
                    "Invalid Paths",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            string[] DMILines = File.ReadAllLines(DMIConfigPath);
            int lineNumber = 0;

            foreach (string line in DMILines)
            {
                lineNumber++;
                if (line.Length == 0 || line.StartsWith("#"))
                    continue; // Skip empty lines and comments

                string[] parts = GetPartsFromLine(line);

                if (parts.Length != 2)
                {
                    MessageBox.Show(
                        $"Invalid Syntax in DMI Config File (line {lineNumber})",
                        "Invalid Syntax",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    continue;
                }

                string sourcePath = Path.Combine(Path.GetDirectoryName(DMIConfigPath) ?? string.Empty, parts[0].Trim());
                string destPath = Path.Combine(RDR2Path, parts[1].Trim());

                try
                {
                    label3.Text = $"Copying '{parts[0].Trim()}' to '{parts[1].Trim()}'...";
                    label3.Refresh(); // force the label to update immediately

                    if (Directory.Exists(sourcePath))
                    {
                        string finalDest = Path.Combine(destPath, Path.GetFileName(sourcePath)); // preserve folder
                        CopyAll(sourcePath, finalDest);
                        label3.Text = $"Copied folder '{parts[0].Trim()}' successfully.";
                        label3.Refresh();
                    }
                    else if (File.Exists(sourcePath))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(destPath) ?? string.Empty);
                        File.Copy(sourcePath, destPath, true);
                        label3.Text = $"Copied file '{parts[0].Trim()}' successfully.";
                        label3.Refresh();
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Source path '{sourcePath}' does not exist (line {lineNumber}).",
                            "Source Not Found",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error copying '{sourcePath}' to '{destPath}': {ex.Message}",
                        "Copy Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }

            label3.Text = "Status: Installation completed successfully!";
            MessageBox.Show(
                "Mod installation completed!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Browse_DMI_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select DMI file";
                ofd.Filter = "Dutch Mod Installer (*.dmi)|*.dmi";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(ofd.FileName))
                        textBox2.Text = ofd.FileName;
                    else
                        MessageBox.Show(
                            "This file does not exist!",
                            "Invalid File",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
