﻿using PKHeX.Core;
using System.Collections.Generic;
using System.ComponentModel;

namespace SysBot.Pokemon;

public class LegalitySettings
{
    private string DefaultTrainerName = "SysBot";
    private const string Generate = nameof(Generate);
    private const string Misc = nameof(Misc);
    public override string ToString() => "合法性生成设置";

    // Generate
    [Category(Generate), Description("神秘卡片的MGDB目录路径")]
    public string MGDBPath { get; set; } = string.Empty;

    [Category(Generate), Description("重新生成PKM文件的训练家数据，PKM文件文件夹。")]
    public string GeneratePathTrainerInfo { get; set; } = string.Empty;

    [Category(Generate), Description("如果PKM文件与提供的PKM文件都不匹配，则使用默认的原始训练家昵称。")]
    public string GenerateOT
    {
        get => DefaultTrainerName;
        set
        {
            if (!StringsUtil.IsSpammyString(value))
                DefaultTrainerName = value;
        }
    }

    [Category(Generate), Description("如果请求与提供的任何训练家数据文件都不匹配，则使用默认16位的训练家表ID (TID)。这应该是一个5位数。")]
    public ushort GenerateTID16 { get; set; } = 12345;

    [Category(Generate), Description("如果请求与提供的任何训练器数据文件都不匹配，则使用默认16位的训练家里ID (SID)。这应该是一个5位数。")]
    public ushort GenerateSID16 { get; set; } = 54321;

    [Category(Generate), Description("当PKM文件不匹配任何提供的PKM文件时，则使用默认的语言。")]
    public LanguageID GenerateLanguage { get; set; } = LanguageID.English;

    [Category(Generate), Description("如果优先级游戏设置为\"True \"，则使用优先考虑游戏版本开始创建来源版本。如果\"False\"，则使用最新的游戏作为版本。")]
    public bool PrioritizeGame { get; set; } = true;

    [Category(Generate), Description("指定在检查其他游戏之前创建来源版本的第一个游戏，或者如果该字段被设置为\"Any\"，则指定当前游戏。将优先级游戏设置为\"true\"，表示启用。")]
    public GameVersion PrioritizeGameVersion { get; set; } = GameVersion.Any;

    [Category(Generate), Description("S为任何生成的Pokémon设置所有可能的合法证章。")]
    public bool SetAllLegalRibbons { get; set; }

    [Category(Generate), Description("为任何生成的宝可梦设置一个匹配的球(基于宝可梦颜色)。")]
    public bool SetMatchingBalls { get; set; } = true;

    [Category(Generate), Description("如果合法，则强制使用指定的球。")]
    public bool ForceSpecifiedBall { get; set; } = true;

    [Category(Generate), Description("根据游戏RNG生成合法、非异色、8代、来自宝可梦巢穴的宝可梦。")]
    public bool ForceLevel100for50 { get; set; }

    [Category(Generate), Description("在交易必须在Switch游戏之间移动的宝可梦时需要HOME跟踪码。")]
    public bool EnableHOMETrackerCheck { get; set; }

    [Category(Generate), Description("尝试宝可梦遭遇类型的顺序")]
    public List<EncounterTypeGroup> PrioritizeEncounters { get; set; } =
    [
        EncounterTypeGroup.Egg, EncounterTypeGroup.Slot,
        EncounterTypeGroup.Static, EncounterTypeGroup.Mystery,
        EncounterTypeGroup.Trade,
    ];

    [Category(Generate), Description("增加对战版本，支持它(目前仅仅支持剑盾)使用过去的一代宝可梦可以进行在线对战。")]
    public bool SetBattleVersion { get; set; }

    [Category(Generate), Description("如果提供了非法的SET代码，机器人将创建一个复活节的宝可梦蛋。")]
    public bool EnableEasterEggs { get; set; }

    [Category(Generate), Description("允许用户在Showdown sets中提交自定义的OT，TID，SID和OT Gender，即允许用户使用PS代码实现自ID。")]
    public bool AllowTrainerDataOverride { get; set; }

    [Category(Generate), Description("允许用户使用Pkhex批处理编辑命令实现进一步的定制。")]
    public bool AllowBatchCommands { get; set; } = true;

    [Category(Generate), Description("在取消之前生成SET代码时所花费的最大时间(秒)。这可以防止复杂的代码冻结机器人。")]
    public int Timeout { get; set; } = 15;

    // Misc

    [Category(Misc), Description("将HOME跟踪器归零，不管当前跟踪器的值. 同样适用于用户要求的PKM文件。")]
    public bool ResetHOMETracker { get; set; } = false;

    [Category(Misc), Description("由交换对象重写训练家信息。")]
    public bool UseTradePartnerInfo { get; set; } = true;
}
