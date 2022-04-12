// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string direction = "down";
object locker = new object();
void Change()
{
    while (true)
    {
        Thread.Sleep(100);
        lock (locker)
        {
            direction = direction == "down" ? "up" : "down";
        }
    }
}

for (int i = 0; i < 100; i++)
{
    new Thread(Change);
}
