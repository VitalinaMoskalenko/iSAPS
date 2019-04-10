﻿using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace iSAPS
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string LastEmailSettingsKey = "last_email_key";
        private const string LastPasswordSettingsKey = "last_password_key";
        private const string IdStudentSettingsKey = "id_student_password_key";
        private const string IdGroupSettingsKey = "id_group_student_password_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion


        public static string LastUsedEmail
        {
            get
            {
                return AppSettings.GetValueOrDefault(LastEmailSettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LastEmailSettingsKey, value);
            }
        }
        public static string LastPasswordSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(LastPasswordSettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LastPasswordSettingsKey, value);
            }
        }
        public static string IdStudentSetting
        {
            get
            {
                return AppSettings.GetValueOrDefault(IdStudentSettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(IdStudentSettingsKey, value);
            }
        }
        public static string IdGroupSetting
        {
            get
            {
                return AppSettings.GetValueOrDefault(IdGroupSettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(IdGroupSettingsKey, value);
            }
        }

    }
}
