using PKHeX.Core;
using SysBot.Base;
using System.ComponentModel;

namespace SysBot.Pokemon;

public class DistributionSettings : ISynchronizationSetting
{
    private const string Distribute = nameof(Distribute);
    private const string Synchronize = nameof(Synchronize);
    public override string ToString() => "派送机器人设置";

    // Distribute

    [Category(Distribute), Description("当启用时，空闲的连接交换机器人将从Distribute文件夹分发PKM文件。")]
    public bool DistributeWhileIdle { get; set; } = true;

    [Category(Distribute), Description("当启用后，Distribution文件夹将随机产生，而不是按照相同的顺序产生。")]
    public bool Shuffled { get; set; }

    [Category(Distribute), Description("当设置为None以外的值时，随机交易除了匹配昵称外，还需要匹配这个种类的宝可梦。")]
    public Species LedySpecies { get; set; } = Species.None;

    [Category(Distribute), Description("当设置为True时，随机的Ledy nickname-swap交易将退出，而不是从交易文件夹中随机交易一个宝可梦。")]
    public bool LedyQuitIfNoMatch { get; set; }

    [Category(Distribute), Description("派送交换连接密码(0-99999999)")]
    public int TradeCode { get; set; } = 7196;

    [Category(Distribute), Description("派送交换连接密码使用最小值和最大值范围，而不是固定的交换密码。")]
    public bool RandomCode { get; set; }

    [Category(Distribute), Description("对于[珍钻]，派送机器人将进入一个特定的房间并保持在那里，直到机器人停止。")]
    public bool RemainInUnionRoomBDSP { get; set; } = true;

    // Synchronize

    [Category(Synchronize), Description("Link Trade: Using multiple distribution bots -- all bots will confirm their trade code at the same time. When Local, the bots will continue when all are at the barrier. When Remote, something else must signal the bots to continue.")]
    public BotSyncOption SynchronizeBots { get; set; } = BotSyncOption.LocalSync;

    [Category(Synchronize), Description("Link Trade: Using multiple distribution bots -- once all bots are ready to confirm trade code, the Hub will wait X milliseconds before releasing all bots.")]
    public int SynchronizeDelayBarrier { get; set; }

    [Category(Synchronize), Description("Link Trade: Using multiple distribution bots -- how long (seconds) a bot will wait for synchronization before continuing anyways.")]
    public double SynchronizeTimeout { get; set; } = 90;
}
