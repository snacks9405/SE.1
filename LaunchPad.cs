﻿using System;
using SE._1;

public class LaunchPad
{
    public static void Main(String[] args)
    {
        FlatDatabase.initializeDB();
        UserInterface.mainDisplay();
    }
}

