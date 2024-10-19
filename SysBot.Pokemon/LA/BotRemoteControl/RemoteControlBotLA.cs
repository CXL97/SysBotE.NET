using SysBot.Base;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SysBot.Pokemon;

public class RemoteControlBotLA(PokeBotState Config) : PokeRoutineExecutor8LA(Config)
{
    public override async Task MainLoop(CancellationToken token)
    {
        try
        {
            Log("正在识别主机控制台的数据...");
            await IdentifyTrainer(token).ConfigureAwait(false);

            Log("启动主循环，然后等待命令。");
            Config.IterateNextRoutine();
            while (!token.IsCancellationRequested)
            {
                await Task.Delay(1_000, token).ConfigureAwait(false);
                ReportStatus();
            }
        }
        catch (Exception e)
        {
            Log(e.Message);
        }

        Log($"结束 {nameof(RemoteControlBotLA)} 循环.");
        await HardStop().ConfigureAwait(false);
    }

    public override async Task HardStop()
    {
        await SetStick(SwitchStick.LEFT, 0, 0, 0_500, CancellationToken.None).ConfigureAwait(false); // reset
        await CleanExit(CancellationToken.None).ConfigureAwait(false);
    }

    private class DummyReset : IBotStateSettings
    {
        public bool ScreenOff => true;
    }
}
