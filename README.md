ActionpayWPTracker
==================

SDK для внедрения в сторонние проекты с целью отслеживания установки приложения а также целевых действий пользователей.

Внедрение
=========

Линкуем файлы в проект:
-----------------------

 * SmartTracker.dll
 * ODINWP.dll
 * Actionpay.Tracker.Core.dll
 * JsonLight.dll
 * MD5.dll

Инициализация трекера
---------------------

```cs
public sealed partial class App : Application
{
  // ...

  protected override void OnLaunched(LaunchActivatedEventArgs e)
  {
    // ...

    // Инициализация в боевом режиме
    SLTracker.Init ("1" /* App ID */, "trackerexample" /* URL scheme */, null, false /* Ignore SSL? */, testMode: false);
    // Установим время автоматической отсылки событий
    SLTracker.SharedTracker.UpdateInterval(10 /* каждые 10 секунд */, true /* Повторять? */);

    // ...
  }
  
  // ...

  // ЭТО НЕОБХОДИМО СДЕЛАТЬ: Устанавливаем обработчик URL Scheme
  protected override void OnActivated(IActivatedEventArgs args)
  {
    if (args.Kind == ActivationKind.Protocol)
    {
      ProtocolActivatedEventArgs eventArgs = args as ProtocolActivatedEventArgs;

      // The received URI is eventArgs.Uri.AbsoluteUri
      SLTracker.SharedTracker.TrackUrl(eventArgs.Uri);
    }
  }
}
```

Обработка событий

```cs
SLTracker.SharedTracker.BeginSend += (sender, action) => { /* ... */ };
SLTracker.SharedTracker.EndSend += (sender, action) => { /* ... */ };
```

Использование
-------------

Событие происходит только один раз

```cs
SLTracker.SharedTracker.TrackAction("event"); // Повторно событие не отработает
```

Событие отрабатывает каждый раз

```cs
SLTracker.SharedTracker.TrackAction("purchase", "440");
```

Методы отслеживания событий

```cs
// name – имя события
// price – используется при регистрации событий оплаты (если указан этот параметр событие отрабатывает каждый раз)
// order – Идетификатор заказа (Используется совместно с price)
// apid – Постфикс идентификатор (если хотите указать свой постфикс к имени события, в противном случае он будет формироваться автоматически)

Task<bool> trackAction(string name, string price = null, string order = null, string apid = null)
```

Обратная связь
==============
