using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.LazyLoad.Ghost
{
    public abstract class DomainObject
    {
        public int Id { get; }
        LoadStatus Status;

        public DomainObject(int id)
        {
            Id = id;
        }

        public bool IsGhost => Status == LoadStatus.Ghost;
        public bool ILoaded => Status == LoadStatus.Loaded;

        public void MarkLoading() => Status = LoadStatus.Loading;
        public void MarkLoaded() => Status = LoadStatus.Loaded;

        // Template Method Pattern
        public virtual void Load()
        {
            if (!IsGhost) return;

            // Ideally, persistence and mapping are done in seprate classes
            var dataRow = GetDataRow();
            LoadLine(dataRow);
        }

        // Template Method Pattern
        void LoadLine(ArrayList dataRow)
        {
            if (!IsGhost) return;

            MarkLoading();
            DoLoadLine(dataRow);
            MarkLoaded();
        }

        protected abstract void DoLoadLine(ArrayList dataRow);
        protected abstract ArrayList GetDataRow();
    }

    enum LoadStatus
    {
        Ghost,
        Loading,
        Loaded
    }
}
