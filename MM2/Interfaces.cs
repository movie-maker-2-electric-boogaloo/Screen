using MM2.Time;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM2.Api
{
    interface IClip
    {
        Duration Duration();

        IClip Subclip(Instant start, Duration length);

        byte[] Read();
    }

    interface IProject
    {
        IList<ITimeline> Timelines();

        void Save(File to);
        void Load(File from);

        string Name();
    }

    interface ITimeline : IEnumerable<IClip>
    {
        Duration Duration();

        void Add(IClip clip); // adds to end
        void Add(IClip clip, Instant time);

        void Remove(IClip clip);
    }

    interface IPreviewer
    {
        void Preview(IProject project);
    }

    interface IRenderer
    {
        void Write(File to);

        void Compose(IProject project);
    }
}
