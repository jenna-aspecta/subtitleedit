﻿using Nikse.SubtitleEdit.Core.Common;
using Nikse.SubtitleEdit.Core.SubtitleFormats;
using Nikse.SubtitleEdit.Forms.Ocr;
using Nikse.SubtitleEdit.Logic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nikse.SubtitleEdit.Forms.Assa
{
    public sealed partial class ImageColorPicker : Form
    {
        private readonly Bitmap _bitmap;
        private bool _colorPickerOn = true;
        private int _colorPickerX = -1;
        private int _colorPickerY = -1;

        public Color Color { get; set; }
        public string HexColor => Utilities.ColorToHex(Color).ToUpper();
        public string AssaColor => AdvancedSubStationAlpha.GetSsaColorStringNoTransparency(Color);
        public string RgbColor => $"RGB({Color.R},{Color.G},{Color.B})";

        public ImageColorPicker(Bitmap bitmap)
        {
            UiUtil.PreInitialize(this);
            InitializeComponent();
            UiUtil.FixFonts(this);
            UiUtil.FixFonts(contextMenuStripCopy);

            _bitmap = bitmap;
            var screen = Screen.PrimaryScreen.WorkingArea.Size;
            while (_bitmap.Width + 10 >= screen.Width || _bitmap.Height + 40 >= screen.Height)
            {
                _bitmap = OcrPreprocessingT4.ResizeBitmap(_bitmap,
                    (int)Math.Round(_bitmap.Width * 0.75, MidpointRounding.AwayFromZero),
                    (int)Math.Round(_bitmap.Height * 0.75, MidpointRounding.AwayFromZero));
            }

            pictureBoxImage.Image = _bitmap;
            labelInfo.Text = string.Empty;

            Width = _bitmap.Width + 10;
            Height = _bitmap.Height + (Height - pictureBoxImage.Height);

            Text = LanguageSettings.Current.ImageColorPicker.Title;
            copyHexToolStripMenuItem.Text = string.Format(LanguageSettings.Current.ImageColorPicker.CopyColorHex, "#000000");
            copyAssaToolStripMenuItem.Text = string.Format(LanguageSettings.Current.ImageColorPicker.CopyColorAssa, "&H000000");
            copyRgbToolStripMenuItem.Text = string.Format(LanguageSettings.Current.ImageColorPicker.CopyColorRgb, "RGB(0,0,0)");
        }

        private void pictureBoxImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_colorPickerOn)
            {
                return;
            }

            var pos = pictureBoxImage.PointToClient(MousePosition);
            var x = pos.X;
            var y = pos.Y;
            if (x >= 0 && x < _bitmap.Width && y >= 0 && y < _bitmap.Height)
            {
                if (x < _bitmap.Width && y < _bitmap.Height)
                {
                    Color = _bitmap.GetPixel(x, y);
                    panelMouseOverColor.BackColor = Color;
                    labelInfo.Text = $"{RgbColor}      {HexColor}      &{AssaColor}";
                }

                _colorPickerX = x;
                _colorPickerY = y;
            }
        }

        private void contextMenuStripCopy_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            copyHexToolStripMenuItem.Text = string.Format(LanguageSettings.Current.ImageColorPicker.CopyColorHex, HexColor);
            copyAssaToolStripMenuItem.Text = string.Format(LanguageSettings.Current.ImageColorPicker.CopyColorAssa, $"&{AssaColor}");
            copyRgbToolStripMenuItem.Text = string.Format(LanguageSettings.Current.ImageColorPicker.CopyColorRgb, RgbColor);
        }

        private void copyHexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(HexColor);
        }

        private void copyAssaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(AssaColor);
        }

        private void copyRgbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(RgbColor);
        }

        private void pictureBoxImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _colorPickerOn = false;
            Cursor.Current = Cursors.Default;
            DialogResult = DialogResult.OK;
        }

        private void ImageColorPicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
