﻿using System;
using System.ComponentModel;
using System.Resources;

namespace GlobalResources
{
    /// <summary>
    /// 屬性描述多語系
    /// </summary>
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        private readonly string _resourceKey;
        private readonly ResourceManager _resource;
        public LocalizedDescriptionAttribute(string resourceKey, Type resourceType)
        {
            _resource = new ResourceManager(resourceType);
            _resourceKey = resourceKey;
        }

        public override string Description
        {
            get
            {
                string displayName = _resource.GetString(_resourceKey);

                return string.IsNullOrEmpty(displayName)
                    ? string.Format("[[{0}]]", _resourceKey)
                    : displayName;
            }
        }
    }
}
