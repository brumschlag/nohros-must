﻿using System;
using NUnit.Framework;
using Telerik.JustMock;
using Nohros.Extensions;

namespace Nohros.Metrics.Tests
{
  public class ManualMeterTests
  {
    [Test]
    public void should_mark_evets_and_update_rates_count() {
      var meter = new ManualMeter(0);
      meter.Mark(1, 0L.ToNanos(TimeUnit.Seconds));
      meter.Mark(2, 10L.ToNanos(TimeUnit.Seconds));
      Assert.That(meter.OneMinuteRate, Is.InRange(0.1830, 0.1850));
      Assert.That(meter.FiveMinuteRate, Is.InRange(0.1966, 0.1976));
      Assert.That(meter.FifteenMinuteRate, Is.InRange(0.1988, 0.1998));
    }
  }
}
