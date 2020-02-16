using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelaLoginMixer.Models
{
    public class MixerData
    {
        public Mixer.Base.Model.User.PrivatePopulatedUserModel User { get; set; }
        public Mixer.Base.MixerConnection Connection { get; set; }

    }
}