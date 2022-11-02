// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

#nullable disable

using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Localisation;
using osu.Game.Configuration;
using osu.Game.Localisation;

namespace osu.Game.Overlays.Settings.Sections.Gameplay
{
    public class BeatmapSettings : SettingsSubsection
    {
        protected override LocalisableString Header => GameplaySettingsStrings.BeatmapHeader;

        private readonly BindableFloat comboColourBrightness = new BindableFloat();

        [BackgroundDependencyLoader]
        private void load(OsuConfigManager config)
        {
            config.BindWith(OsuSetting.ComboColourBrightness, comboColourBrightness);

            Children = new Drawable[]
            {
                new SettingsCheckbox
                {
                    LabelText = SkinSettingsStrings.BeatmapSkins,
                    Current = config.GetBindable<bool>(OsuSetting.BeatmapSkins)
                },
                new SettingsCheckbox
                {
                    LabelText = SkinSettingsStrings.BeatmapColours,
                    Current = config.GetBindable<bool>(OsuSetting.BeatmapColours)
                },
                new SettingsCheckbox
                {
                    LabelText = SkinSettingsStrings.BeatmapHitsounds,
                    Current = config.GetBindable<bool>(OsuSetting.BeatmapHitsounds)
                },
                new SettingsCheckbox
                {
                    LabelText = GraphicsSettingsStrings.StoryboardVideo,
                    Current = config.GetBindable<bool>(OsuSetting.ShowStoryboard)
                },
                new SettingsSlider<float>
                {
                    LabelText = "Combo colour brightness",
                    Current = comboColourBrightness,
                    DisplayAsPercentage = true,
                }
            };
        }
    }
}
