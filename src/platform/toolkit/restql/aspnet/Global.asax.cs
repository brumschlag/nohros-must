﻿using System;
using System.Web;
using System.Web.Configuration;
using ZMQ;

namespace Nohros.Toolkit.RestQL
{
  public class Global : HttpApplication
  {
    static readonly Context zmq_context_;

    #region .ctor
    static Global() {
      zmq_context_ = new Context(ZMQ.Context.DefaultIOThreads);
    }
    #endregion

    protected void Application_Start(object sender, EventArgs e) {
      string config_file_name =
        WebConfigurationManager.AppSettings[Strings.kConfigFileNameKey];
      string config_file_path = Server.MapPath(config_file_name);
      Settings settings = new Settings.Loader()
        .Load(config_file_path, Strings.kConfigRootNodeName);
      var socket = zmq_context_.Socket(SocketType.REQ);
      Application[Strings.kSettingsKey] = settings;
      Application[Strings.kSocketKey] = socket;
    }

    protected void Session_Start(object sender, EventArgs e) {
    }

    protected void Application_BeginRequest(object sender, EventArgs e) {
    }

    protected void Application_AuthenticateRequest(object sender, EventArgs e) {
    }

    protected void Application_Error(object sender, EventArgs e) {
    }

    protected void Session_End(object sender, EventArgs e) {
    }

    protected void Application_End(object sender, EventArgs e) {
      var socket = Application[Strings.kSocketKey] as Socket;
      if (socket != null) {
        socket.Dispose();
      }
    }
  }
}
