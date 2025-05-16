using System;
using System.Collections.Generic;

public class Program
{
    private static void Main()
    {
        Model model = new Model();
        View view = new View();
        Controller controller = new Controller(model, view);

        controller.RunGame();
    }
}