using UnityEditor;
using UnityEditor.Rendering;

namespace UnityEngine.Experimental.Rendering.HDPipeline
{
    [CanEditMultipleObjects]
    [VolumeComponentEditor(typeof(ContactShadows))]
    public class ContactShadowsEditor : VolumeComponentEditor
    {
        SerializedDataParameter m_Enable;
        SerializedDataParameter m_Length;
        SerializedDataParameter m_DistanceScaleFactor;
        SerializedDataParameter m_MaxDistance;
        SerializedDataParameter m_FadeDistance;
        SerializedDataParameter m_SampleCount;
        SerializedDataParameter m_Opacity;


        public override void OnEnable()
        {
            var o = new PropertyFetcher<ContactShadows>(serializedObject);

            m_Enable = Unpack(o.Find(x => x.enable));
            m_Length = Unpack(o.Find(x => x.length));
            m_DistanceScaleFactor = Unpack(o.Find(x => x.distanceScaleFactor));
            m_MaxDistance = Unpack(o.Find(x => x.maxDistance));
            m_FadeDistance = Unpack(o.Find(x => x.fadeDistance));
            m_SampleCount = Unpack(o.Find(x => x.sampleCount));
            m_Opacity = Unpack(o.Find(x => x.opacity));
        }

        public override void OnInspectorGUI()
        {
            PropertyField(m_Enable, CoreEditorUtils.GetContent("Enable|Tick this checkbox to allow HDRP to process Contact Shadows for this Volume."));

            if (!m_Enable.value.hasMultipleDifferentValues)
            {
                using (new EditorGUI.DisabledGroupScope(!m_Enable.value.boolValue))
                {
                    PropertyField(m_Length, CoreEditorUtils.GetContent("Length|Controls the length of the rays HDRP uses to calculate Contact Shadows. Uses meters."));
                    PropertyField(m_DistanceScaleFactor, CoreEditorUtils.GetContent("Distance Scale Factor|Dampens the scale up effect HDRP process with distance from the Camera."));
                    PropertyField(m_MaxDistance, CoreEditorUtils.GetContent("Max Distance|Sets The distance from the Camera at which HDRP begins to fade out Contact Shadows. Uses meters."));
                    PropertyField(m_FadeDistance, CoreEditorUtils.GetContent("Fade Distance|Sets the distance over which HDRP fades Contact Shadows out when at the Max Distance. Uses meters."));
                    PropertyField(m_SampleCount, CoreEditorUtils.GetContent("Sample Count|Controls the number of samples HDRP uses for ray casting."));
                    PropertyField(m_Opacity, CoreEditorUtils.GetContent("Opacity|Controls the opacity of the Contact Shadow."));
                }
            }
        }
    }
}
