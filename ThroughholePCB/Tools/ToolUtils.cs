using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThroughholePCB.Tools
{
    public static class ToolUtils
    {
        /// <summary>
        /// converts a position that is relative to the picturebox to a position that is relative to the image
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="pictureBoxPos"></param>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static Point GetImagePos(PictureBox pictureBox, Point pictureBoxPos, Grid? grid = null)
        {
            int offsetX = (pictureBox.Width - pictureBox.Image.Width) / 2;
            int offsetY = (pictureBox.Height - pictureBox.Image.Height) / 2;
            int clickX = pictureBoxPos.X - offsetX;
            int clickY = pictureBoxPos.Y - offsetY;

            var point = new Point(clickX, clickY);
            if (grid != null)
            {
                return grid.GetAligned(point);
            }
            return point;
        }

        /// <summary>
        /// Calculates the position of an image point within a PictureBox control, optionally aligning it to a grid.
        /// </summary>
        /// <remarks>The method accounts for the centering of the image within the PictureBox. If a grid
        /// is provided, the returned point is aligned according to the grid's alignment logic.</remarks>
        /// <param name="pictureBox">The PictureBox control containing the image. Must not be null and must have a non-null Image property.</param>
        /// <param name="imagePos">The coordinates of the point within the image, relative to the image's top-left corner.</param>
        /// <param name="grid">An optional grid to which the resulting point will be aligned. If null, no alignment is performed.</param>
        /// <returns>A Point representing the position within the PictureBox that corresponds to the specified image coordinates,
        /// adjusted for centering and optional grid alignment.</returns>
        public static Point GetPictureBoxPos(PictureBox pictureBox, Point imagePos, Grid? grid = null)
        {
            int offsetX = (pictureBox.Width - pictureBox.Image.Width) / 2;
            int offsetY = (pictureBox.Height - pictureBox.Image.Height) / 2;
            var point = new Point(imagePos.X + offsetX, imagePos.Y + offsetY);
            if (grid != null)
            {
                return grid.GetAligned(point);
            }
            return point;
        }
    }
}
