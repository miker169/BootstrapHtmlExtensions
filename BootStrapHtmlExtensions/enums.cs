using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootStrapHtmlExtensions
{
    /// <summary>
    /// Button Types, determines the coloring/effects
    /// </summary>
    public enum ButtonType
    {
        /// <summary>
        /// default button type
        /// </summary>
        @default,

        /// <summary>
        /// primary button type
        /// </summary>
        primary,

        /// <summary>
        /// info button type
        /// </summary>
        info,

        /// <summary>
        /// success button type
        /// </summary>
        success,

        /// <summary>
        /// warning button type
        /// </summary>
        warning,

        /// <summary>
        /// danger button type
        /// </summary>
        danger



    }

    /// <summary>
    /// Button Sizes, determines the height, width and text size
    /// </summary>
    public enum ButtonSize
    {
        /// <summary>
        /// default button size
        /// </summary>
        @default,

        /// <summary>
        /// large button size
        /// </summary>
        large,

        /// <summary>
        /// small button size
        /// </summary>
        small

    }

    /// <summary>
    /// Input sizes, determines the width of the input
    /// </summary>
    public enum InputSize
    {
        /// <summary>
        /// small input size
        /// </summary>
        small,

        /// <summary>
        /// medium input size
        /// </summary>
        medium,

        /// <summary>
        /// large input size
        /// </summary>
        large

    }
}
