﻿using EmuLibrary.RomTypes;
using Playnite.SDK;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static EmuLibrary.EmuLibrarySettings;

namespace EmuLibrary
{
    internal class EmuLibrarySettingsV0 : ObservableObject, ISettings
    {
        public class ROMInstallerEmulatorMappingV0 : ObservableObject
        {
            public ROMInstallerEmulatorMappingV0() { }
            public bool Enabled { get; set; }
            public Guid EmulatorId { get; set; }
            public string EmulatorProfileId { get; set; }
            public string PlatformId { get; set; }
            public string SourcePath { get; set; }
            public string DestinationPath { get; set; }
            public bool GamesUseFolders { get; set; }
        }

        public ObservableCollection<ROMInstallerEmulatorMappingV0> Mappings { get; set; }

        public bool VerifySettings(out List<string> errors)
        {
            throw new NotImplementedException();
        }

        public void BeginEdit()
        {
            throw new NotImplementedException();
        }

        public void EndEdit()
        {
            throw new NotImplementedException();
        }

        public void CancelEdit()
        {
            throw new NotImplementedException();
        }

        public EmuLibrarySettings ToV1Settings()
        {
            var settings = new EmuLibrarySettings()
            {
                Mappings = new ObservableCollection<ROMInstallerEmulatorMapping>(),
                Version = 1,
            };

            Mappings?.ForEach(mapping =>
            {
                settings.Mappings.Add(new ROMInstallerEmulatorMapping()
                {
                    Enabled = mapping.Enabled,
                    EmulatorId = mapping.EmulatorId,
                    EmulatorProfileId = mapping.EmulatorProfileId,
                    PlatformId = mapping.PlatformId,
                    SourcePath = mapping.SourcePath,
                    DestinationPath = mapping.DestinationPath,
                    RomType = mapping.GamesUseFolders ? RomType.MultiFile : RomType.SingleFile
                });
            });

            return settings;
        }
    }
}
