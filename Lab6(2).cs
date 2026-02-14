using System;

abstract class UIWindow
{
    public string Title { get; set; }

    public UIWindow(string title)
    {
        Title = title;
    }

    public abstract void Draw();

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Вікно: {Title}");
    }
}

class MainWindow : UIWindow
{
    public MainWindow(string title) : base(title) { }

    public override void Draw()
    {
        Console.WriteLine($"Відмальовування головного вікна: {Title}");
    }
}

class ModalWindow : UIWindow
{
    public ModalWindow(string title) : base(title) { }

    public override void Draw()
    {
        Console.WriteLine($"Відмальовування модального вікна: {Title}");
    }

    public void BlockParent()
    {
        Console.WriteLine("Батьківське вікно заблоковано.");
    }
}

interface IClosable
{
    void Close();
}

class Dialog : UIWindow, IClosable
{
    public Dialog(string title) : base(title) { }

    public override void Draw()
    {
        Console.WriteLine($"Відмальовування діалогового вікна: {Title}");
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine($"Повідомлення: {message}");
    }

    public void Close()
    {
        Console.WriteLine("Діалогове вікно закрито.");
    }
}

class Program
{
    static void Main()
    {
        UIWindow[] windows = new UIWindow[]
        {
            new MainWindow("Головне меню"),
            new ModalWindow("Налаштування"),
            new Dialog("Повідомлення")
        };

        foreach (UIWindow window in windows)
        {
            window.ShowInfo();
            window.Draw();
            Console.WriteLine();
        }
    }
}
