namespace Notas.Pages;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

    public string ItemId
    {
        set { LoadNote(value); }
    }

    public NotePage()
    {
        InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));


        if (File.Exists(_fileName))
            TextEditor.Text = File.ReadAllText(_fileName);
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
        {
            // Obtiene el titulo de la nota
            string title = note.Title;

            // crea el archivo con el nombre de la nota
            string filename = $"{title}.notes.txt";

            // Guardar el texto en el archivo
            File.WriteAllText(Path.Combine(FileSystem.AppDataDirectory, filename), TextEditor.Text);
        }

        await Shell.Current.GoToAsync("..");
    }



    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
        {
            // Delete the file.
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void LoadNote(string fileName)
    {
        Models.Note noteModel = new Models.Note();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }

}