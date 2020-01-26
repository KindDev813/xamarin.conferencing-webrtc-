﻿// This file has been autogenerated from a class added in the UI designer.

using System;
using UIKit;
using WebRTC.Abstraction;
using WebRTC.AppRTC;

namespace WebRTC.iOS.Demo
{
    public partial class VideoCallViewController : UIViewController, IAppRTCClientListener, IWebSocketConnectionFactory,
        IVideoCapturerFactory
    {
        private AppRTCClient _appRTCClient;

        public VideoCallViewController(IntPtr handle) : base(handle)
        {
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Video call";
            Platform.Init();

            _appRTCClient = new AppRTCClient(new AppRTCClientConfig(H113Constants.Token, H113Constants.WssUrl), this,
                this);
            await _appRTCClient.ConnectAsync(H113Constants.Phone);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            _appRTCClient.Disconnect();
        }

        public void DidCreatePeerConnection(IPeerConnection peerConnection)
        {
        }

        public void DidOpenDataChannel(IDataChannel dataChannel)
        {
        }

        public void DidChangeState(AppClientState state)
        {
        }

        public void DidReceiveLocalVideoTrack(IVideoTrack videoTrack)
        {
        }

        public void DidReceiveRemoteVideoTrack(IVideoTrack videoTrack)
        {
        }

        public void DidCreateCapturer(IVideoCapturer videoCapturer)
        {
        }

        public void DidRegisterWithCollider()
        {
        }

        public void OnError(AppRTCException error)
        {
        }

        public IWebSocketConnection CreateWebSocket() => new WebSocketConnection();

        public IVideoCapturer CreateCapturer(IVideoSource videoSource, IPeerConnectionFactory factory) =>
            factory.CreateFileCapturer(videoSource, "foreman.mp4");
    }
}