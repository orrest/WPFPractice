
using System.Collections.Generic;

namespace RedditBrowser.Services;

public sealed class SettingsService : ISettingsService
{
    private Dictionary<string, object> _settings;
    /// <inheritdoc/>
    public void SetValue<T>(string key, T value)
    {
        if (!_settings.ContainsKey(key)) _settings.Add(key, value);
        else _settings[key] = value;
    }

    /// <inheritdoc/>
    public T GetValue<T>(string key)
    {
        if (_settings.TryGetValue(key, out object value))
        {
            return (T)value;
        }

        return default;
    }
}