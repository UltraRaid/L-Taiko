﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using FDK;

namespace TJAPlayer3
{
    internal class CAct演奏DrumsFooter : CActivity
    {
        /// <summary>
        /// フッター
        /// </summary>
        public CAct演奏DrumsFooter()
        {
            base.IsDeActivated = true;
        }

        public override void Activate()
        {
            var footerDir = CSkin.Path($"{TextureLoader.BASE}{TextureLoader.GAME}{TextureLoader.FOOTER}");
            var preset = HScenePreset.GetBGPreset();

            if (System.IO.Directory.Exists(footerDir))
            {
                Random random = new Random();

                var upDirs = System.IO.Directory.GetFiles(footerDir);
                if (upDirs.Length > 0)
                {
                    var _presetPath = (preset != null && preset.FooterSet != null) ? $@"{footerDir}" + preset.FooterSet[random.Next(0, preset.FooterSet.Length)] + ".png" : "";
                    var path = (preset != null && System.IO.File.Exists(_presetPath)) 
                        ?  _presetPath
                        : upDirs[random.Next(0, upDirs.Length)];

                    Mob_Footer = TJAPlayer3.tテクスチャの生成(path);
                }
            }

            base.Activate();
        }

        public override void DeActivate()
        {
            TJAPlayer3.tDisposeSafely(ref Mob_Footer);

            base.DeActivate();
        }

        public override void CreateManagedResource()
        {
            base.CreateManagedResource();
        }

        public override void ReleaseManagedResource()
        {
            base.ReleaseManagedResource();
        }

        public override int Draw()
        {
            if (this.Mob_Footer != null)
            {
                this.Mob_Footer.t2D描画(0, TJAPlayer3.Skin.Resolution[1] - this.Mob_Footer.szTextureSize.Height);
            }
            return base.Draw();
        }

        #region[ private ]
        //-----------------
        public CTexture Mob_Footer;
        //-----------------
        #endregion
    }
}
