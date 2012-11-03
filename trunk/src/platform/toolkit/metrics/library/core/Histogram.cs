﻿using System;

namespace Nohros.Metrics
{
  /// <summary>
  /// An abstract implementation of the <see cref="IHistogram"/> that reduces
  /// the effort required to implement that interface. Implementors should
  /// implement only the <see cref="Snapshot"/> property. The default
  /// implementation thows a <see cref="NotImplementedException"/>.
  /// </summary>
  public abstract class AbstractHistogram : IHistogram
  {
    readonly double[] variance_;
    long count_;
    long max_;
    long min_;
    long sum_;

    #region .ctor
    /// <summary>
    /// Initialize a new instance of the <see cref="AbstractHistogram"/> class.
    /// </summary>
    protected AbstractHistogram() {
      min_ = long.MaxValue;
      max_ = long.MinValue;
      sum_ = 0;
      count_ = 0;
      variance_ = new double[] {-1, 0}; //M,S
    }
    #endregion

    /// <summary>
    /// Adds a recorded value.
    /// </summary>
    public virtual void Update(long value) {
      count_++;
      if (value > max_) {
        max_ = value;
      }
      if (value < min_) {
        min_ = value;
      }
      sum_ += value;
      UpdateVariance(value);
    }

    /// <inheritdoc/>
    public abstract Snapshot Snapshot { get; }

    /// <inheritdoc/>
    public virtual double Max {
      get { return (count_ > 0) ? max_ : 0.0; }
    }

    /// <inheritdoc/>
    public virtual double Min {
      get { return (count_ > 0) ? min_ : 0.0; }
    }

    /// <inheritdoc/>
    public virtual double Mean {
      get { return (count_ > 0) ? sum_/(double) count_ : 0.0; }
    }

    /// <inheritdoc/>
    public virtual double StandardDeviation {
      get { return (count_ > 0) ? Math.Sqrt(Variance) : 0.0; }
    }

    /// <summary>
    /// Get the number of values recorded.
    /// </summary>
    /// <returns>The number of values recorded.</returns>
    public virtual long Count {
      get { return count_; }
    }

    /// <summary>
    /// Adds the specified long value to the variance calculation.
    /// </summary>
    /// <param name="value">
    /// The be added to the variance calculation.
    /// </param>
    void UpdateVariance(long value) {
      if (variance_[0] == -1) {
        variance_[0] = value;
        variance_[1] = 0;
      } else {
        double old_m = variance_[0];
        variance_[0] += ((value - variance_[0])/count_);
        variance_[1] += ((value - old_m)*(value - variance_[0]));
      }
    }

    double Variance {
      get { return (count_ <= 1) ? 0.0 : variance_[1]/(count_ - 1); }
    }
  }
}