/*
 * Author: Wundero
 * This class serves as time representations for the project in a more unified internal way.
 * I will probably use time management libraries as a backend but for now this is fine.
 */

namespace MM2.Time
{

    interface Time
    {
        long Millis();
        long Seconds();
        long Minutes();
        long Hours();
    }

    class Instant : Time
    {
        private long ms;

        private Instant() { }
        private Instant(long ms) => this.ms = ms;

        public long Millis() => ms;

        public long Seconds() => ms / 1000;

        public long Minutes() => Seconds() / 60;

        public long Hours() => Minutes() / 60;

        public static Instant operator+ (Instant a, Instant b) => a.Add(b);

        public Instant Add(Instant other) => new Instant(this.ms + other.ms);

        public override bool Equals(object obj) => base.Equals(obj) || (obj is Instant && ((Instant) obj).ms == this.ms);

        public override int GetHashCode() => (int) ms;

        public override string ToString()
        {
            return base.ToString();
        }
    }

    class Duration : Time
    {

        private Instant start;
        private Instant end;
        private long ms;

        private Duration() { }

        private Duration(Instant s, Instant e)
        {
            this.start = s;
            this.end = e;
            this.ms = e.Millis() - s.Millis();
        }

        public long Millis() => ms;

        public long Seconds() => Millis() / 1000;

        public long Minutes() => Seconds() / 60;

        public long Hours() => Minutes() / 60;

        public static Duration operator+ (Duration a, Duration b) => a.Add(b);

        public Duration Add(Duration other) => new Duration(this.start, other.end.Add(this.end));

        public override bool Equals(object obj) => base.Equals(obj) || (obj is Duration && ((Duration)obj).start.Equals(start) && ((Duration)obj).end.Equals(end));

        public override int GetHashCode() => (int)Millis();

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
