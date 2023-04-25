using BakingStore.Components.UI;
using BakingStore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BakingStore.Services;

public class ToastService
{
	public Toast Toast;
	private Queue<(string, ToastResult)> messages = new();
	private Task notifyTask;

	public ToastService()
	{
		notifyTask = Task.Run(RunNotify);
	}
	public async Task RunNotify()
	{
        while (messages.Count > 0)
            if (messages.TryDequeue(out var result))
            {
                Toast.Message = result.Item1;
                Toast.Result = result.Item2;
                Toast.Show();
                await Task.Delay(2000);
                await Toast.Hide();
            }
	}
	public void NotifyAsync(string message, ToastResult result)
	{
		messages.Enqueue((message, result));
		if (notifyTask.IsCompleted)
		{
			notifyTask.Dispose();
			notifyTask = Task.Run(RunNotify);
		}

	}
	public void NotifySucessAsync(string message)
	{
		NotifyAsync(message, ToastResult.Success);
	}
	public void NotifyFailedAsync(string message)
	{
		NotifyAsync(message, ToastResult.Failed);
	}
	public void NotifyWarningAsync(string message)
	{
		NotifyAsync(message, ToastResult.Warning);
	}
}
