﻿using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace JsonSettings.Modulation {
    /// <summary>
    ///     A module that can be attached to a <see cref="ISocket"/>
    /// </summary>
    public abstract class Module : IDisposable {
        internal bool _isattached = false;
        private JsonSettings _socket = null;
        public virtual void Attach(JsonSettings socket) {
            if (_isattached) throw new ModularityException("The module is already attached.");
            _isattached = true;
            _socket = socket;
        }

        public virtual void Deattach(JsonSettings socket) {
            if (_socket==null) throw new ModularityException("The module is not attached.");
            _socket = null;
        }

        public void Dispose() {
            try {
                if (_socket != null)
                    Deattach(_socket);
            } catch { }
        }
    }
}