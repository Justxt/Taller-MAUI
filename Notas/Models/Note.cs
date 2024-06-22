using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notas.Models;

    internal class Note
    {
        public string Filename { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

    public Note()
        {
            Filename = $"{Path.GetRandomFileName()}.notes.txt";
            Date = DateTime.Now;
            Text = "";
        }

        public void Save() =>
        File.WriteAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename), Text);

        public void SaveWithTitle(string title, string text)
        {
            // Construye el nuevo nombre de archivo usando el título
            string newFilename = $"{title}.notes.txt";

            // Escribe el texto en el nuevo archivo
            File.WriteAllText(Path.Combine(FileSystem.AppDataDirectory, newFilename), text);

            // Elimina el archivo anterior si el nombre cambió
            if (Filename != newFilename && File.Exists(Path.Combine(FileSystem.AppDataDirectory, Filename)))
            {
                File.Delete(Path.Combine(FileSystem.AppDataDirectory, Filename));
            }

            // Actualiza la propiedad Filename
            Filename = newFilename;
            Date = DateTime.Now;
        }

    public void Delete() =>
            File.Delete(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename));

        public static Note Load(string filename)
        {
            filename = System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);

            if (!File.Exists(filename))
                throw new FileNotFoundException("Unable to find file on local storage.", filename);

            return
                new()
                {
                    Title = Path.GetFileNameWithoutExtension(filename).Replace(".notes", ""),
                    Filename = Path.GetFileName(filename),
                    Text = File.ReadAllText(filename),
                    Date = File.GetLastWriteTime(filename)
                };
        }

        public static IEnumerable<Note> LoadAll()
        {
            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            return Directory

                    // Select the file names from the directory
                    .EnumerateFiles(appDataPath, "*.notes.txt")

                    // Each file name is used to load a note
                    .Select(filename => Note.Load(Path.GetFileName(filename)))

                    // With the final collection of notes, order them by date
                    .OrderByDescending(note => note.Date);
        }
    }