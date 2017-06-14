/*
 * modifies gta4's inside car -camera (locked, bonnet cam) to where you want it to be (parameters from params.txt)
 * mjt, 2010
 * 
 * params.txt format is
 *     cam_xpos cam_zpos cam_height  x_rotation y_rotation z_rotation FOV
 *  ie, 
 *     0 -5 1.5 -0.1 0 0 95 
 *  so camera is behind and above the car, looking a bit down.
 *  
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace GTA4cammod
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr;
            string str, txt = "";
            sr = File.OpenText("params.txt");
            str = sr.ReadLine();
            string[] par = str.Split(' ');
            sr.Close();

            sr = File.OpenText("vehoff.csv");
            while (true)
            {
                str = sr.ReadLine();
                if (str == null) break;

                if (str.Contains("BONNET_FWD"))
                {
                    string[] bl = str.Split(' ');
                    string tmp = "VEHICLE " + bl[1] + " FIELD BONNET_FWD POS " + par[0] + " " + par[1] + " " + par[2] +
                        " ANGLES " + par[3] + " " + par[4] + " " + par[5] + " " +
                        " FOV " + par[6];
                    str = tmp;
                }
                txt += str + "\n";
            }
            sr.Close();

            StreamWriter sw;
            sw = File.CreateText("vehoff.csv");
            sw.WriteLine(txt);
            sw.Close();
            Console.WriteLine("OK");
        }
    }
}
