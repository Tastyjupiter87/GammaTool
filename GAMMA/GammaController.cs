using System;
using System.Runtime.InteropServices;

namespace GAMMA
{
    public class GammaController
    {
        [DllImport("gdi32.dll")]
        private static extern bool SetDeviceGammaRamp(IntPtr hDC, ref RAMP lpRamp);

        [DllImport("gdi32.dll")]
        private static extern bool GetDeviceGammaRamp(IntPtr hDC, ref RAMP lpRamp);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct RAMP
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public ushort[] Red;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public ushort[] Green;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public ushort[] Blue;
        }

        private RAMP originalRamp;
        private bool hasStoredOriginal = false;

        public bool SetGamma(double gamma)
        {
            try
            {
                IntPtr hDC = GetDC(IntPtr.Zero);
                if (hDC == IntPtr.Zero) return false;

                // Store original gamma if we haven't already
                if (!hasStoredOriginal)
                {
                    GetDeviceGammaRamp(hDC, ref originalRamp);
                    hasStoredOriginal = true;
                }

                // Create new gamma ramp
                RAMP newRamp = CreateGammaRamp(gamma);
                
                // Apply the gamma
                bool result = SetDeviceGammaRamp(hDC, ref newRamp);
                
                ReleaseDC(IntPtr.Zero, hDC);
                return result;
            }
            catch
            {
                return false;
            }
        }

        public bool RestoreOriginalGamma()
        {
            if (!hasStoredOriginal) return false;

            try
            {
                IntPtr hDC = GetDC(IntPtr.Zero);
                if (hDC == IntPtr.Zero) return false;

                bool result = SetDeviceGammaRamp(hDC, ref originalRamp);
                ReleaseDC(IntPtr.Zero, hDC);
                return result;
            }
            catch
            {
                return false;
            }
        }

        private RAMP CreateGammaRamp(double gamma)
        {
            RAMP ramp = new RAMP
            {
                Red = new ushort[256],
                Green = new ushort[256],
                Blue = new ushort[256]
            };

            for (int i = 0; i < 256; i++)
            {
                double value = Math.Pow(i / 255.0, 1.0 / gamma) * 65535.0;
                ushort correctedValue = (ushort)Math.Max(0, Math.Min(65535, value));
                
                ramp.Red[i] = correctedValue;
                ramp.Green[i] = correctedValue;
                ramp.Blue[i] = correctedValue;
            }

            return ramp;
        }
    }
}

