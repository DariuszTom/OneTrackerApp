using System;
using System.Runtime.Serialization;

namespace SharedLibrary.Developer
{
    [Serializable()]
    [DataContract]
    public class DevStats : IComparable
    {
        private int _DevId;
        private long _Project;
        private long _ProjectAfterDeadline;
        private long _CriticalProjectsWithTwoWeeksDeadline;
        private DateTime _LastUpdate;

        [DataMember]
        private double _Score;

        [DataMember]
        private string _FullName;

        public DevStats(int devId)
        {
            DevId = devId;
        }

        public int DevId { get => _DevId; set => _DevId = value; }
        public long Project { get => _Project; set => _Project = value; }
        public long ProjectAfterDeadline { get => _ProjectAfterDeadline; set => _ProjectAfterDeadline = value; }

        public long CriticalProjectsWithTwoWeeksDeadline
        { get => _CriticalProjectsWithTwoWeeksDeadline; set => _CriticalProjectsWithTwoWeeksDeadline = value; }

        public DateTime LastUpdate { get => _LastUpdate; set => _LastUpdate = value; }
        public double Score { get => _Score; set => _Score = Math.Round(value, 3); }
        public string FullName { get => _FullName; set => _FullName = value; }

        public int CompareTo(object obj)
        {
            var item = (DevStats)obj;
            return Score.CompareTo(item._Score);
        }
    }
}