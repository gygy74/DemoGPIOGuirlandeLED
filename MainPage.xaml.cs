// Copyright (c) Microsoft. All rights reserved.

using System;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace Blinky
{
    public sealed partial class MainPage : Page
    {
        private const int LED_RED = 2;
        private const int LED_GREEN = 3;
        private const int LED_YELLOW = 4;
        private const int LED_BLUE = 5;
        private const int LED_WHITE = 6;
        private GpioPin pin0;
        private GpioPin pin1;
        private GpioPin pin2;
        private GpioPin pin3;
        private GpioPin pin4;

        private GpioPinValue pinValue;
        private GpioPinValue pinValue1;

        public MainPage()
        {
            InitializeComponent();

            var gpio = GpioController.GetDefault();

            pin0 = gpio.OpenPin(LED_RED);
            pin1 = gpio.OpenPin(LED_GREEN);
            pin2 = gpio.OpenPin(LED_YELLOW);
            pin3 = gpio.OpenPin(LED_BLUE);
            pin4 = gpio.OpenPin(LED_WHITE);

            pin0.SetDriveMode(GpioPinDriveMode.Output);
            pin1.SetDriveMode(GpioPinDriveMode.Output);
            pin2.SetDriveMode(GpioPinDriveMode.Output);
            pin3.SetDriveMode(GpioPinDriveMode.Output);
            pin4.SetDriveMode(GpioPinDriveMode.Output);

            pinValue = GpioPinValue.Low;
            pinValue1 = GpioPinValue.High;
            while(true)
            {
                pin0.Write(pinValue);
                Task.Delay(100).Wait();
                pin0.Write(pinValue1);
                pin1.Write(pinValue);
                Task.Delay(100).Wait();
                pin1.Write(pinValue1);
                pin2.Write(pinValue);
                Task.Delay(100).Wait();
                pin2.Write(pinValue1);
                pin3.Write(pinValue);
                Task.Delay(100).Wait();
                pin3.Write(pinValue1);
                pin4.Write(pinValue);
                Task.Delay(100).Wait();
                pin4.Write(pinValue1);
            }     
        }    
    }
}
