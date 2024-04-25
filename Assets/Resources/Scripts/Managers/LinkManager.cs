using UnityEngine;

namespace water_color_sorting.Resources.Scripts.Managers
{
    public class LinkManager : MonoBehaviour
    {
        [SerializeField]
        private string _privacyPolicywp;
        [SerializeField]
        private string _rateUsAndriodLink;
        [SerializeField]
        private string _rateUsIOSLink;
        [SerializeField]
        private string _shareAppAndroidLink;
        [SerializeField]
        private string _shareAppIOSLink;
        
        
        public void OpenPrivacy()
        {
            Application.OpenURL(_privacyPolicywp);
        }
        
        public void RateUSToStore()
        {
#if UNITY_IOS
            Application.OpenURL(_rateUsIOSLink);
            //Application.OpenURL("https://play.google.com/store/apps/details?id=" + Application.identifier);
#elif UNITY_ANDROID
           Application.OpenURL(_rateUsAndriodLink);
            //Application.OpenURL("https://play.google.com/store/apps/details?id=" + Application.identifier);
#endif
        }
        
        public void ShareLink()
        {
#if UNITY_IOS
            new NativeShare()
                .SetUrl(_shareAppIOSLink)
                .Share();
#elif UNITY_ANDROID
            new NativeShare()
                .SetUrl(_shareAppAndroidLink)
                .Share(); 
#endif

        }
    }
}
