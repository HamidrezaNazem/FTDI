using System;
using System.Windows.Forms;
//using FTD2XX_NET;

namespace app
{
             
    static class Program
    {
     
    static void Main(string[] args)
    {
       
           // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FTDI_I2C());
        }


    }
}
