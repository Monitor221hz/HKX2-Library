using System;
using System.Collections.Generic;
using System.Numerics;

namespace HKX2
{
    // hkxScene Signatire: 0x5f673ddd size: 224 flags: FLAGS_NONE

    // m_modeller m_class:  Type.TYPE_STRINGPTR Type.TYPE_VOID arrSize: 0 offset: 16 flags:  enum: 
    // m_asset m_class:  Type.TYPE_STRINGPTR Type.TYPE_VOID arrSize: 0 offset: 24 flags:  enum: 
    // m_sceneLength m_class:  Type.TYPE_REAL Type.TYPE_VOID arrSize: 0 offset: 32 flags:  enum: 
    // m_rootNode m_class: hkxNode Type.TYPE_POINTER Type.TYPE_STRUCT arrSize: 0 offset: 40 flags:  enum: 
    // m_selectionSets m_class: hkxNodeSelectionSet Type.TYPE_ARRAY Type.TYPE_POINTER arrSize: 0 offset: 48 flags:  enum: 
    // m_cameras m_class: hkxCamera Type.TYPE_ARRAY Type.TYPE_POINTER arrSize: 0 offset: 64 flags:  enum: 
    // m_lights m_class: hkxLight Type.TYPE_ARRAY Type.TYPE_POINTER arrSize: 0 offset: 80 flags:  enum: 
    // m_meshes m_class: hkxMesh Type.TYPE_ARRAY Type.TYPE_POINTER arrSize: 0 offset: 96 flags:  enum: 
    // m_materials m_class: hkxMaterial Type.TYPE_ARRAY Type.TYPE_POINTER arrSize: 0 offset: 112 flags:  enum: 
    // m_inplaceTextures m_class: hkxTextureInplace Type.TYPE_ARRAY Type.TYPE_POINTER arrSize: 0 offset: 128 flags:  enum: 
    // m_externalTextures m_class: hkxTextureFile Type.TYPE_ARRAY Type.TYPE_POINTER arrSize: 0 offset: 144 flags:  enum: 
    // m_skinBindings m_class: hkxSkinBinding Type.TYPE_ARRAY Type.TYPE_POINTER arrSize: 0 offset: 160 flags:  enum: 
    // m_appliedTransform m_class:  Type.TYPE_MATRIX3 Type.TYPE_VOID arrSize: 0 offset: 176 flags:  enum: 
    
    public class hkxScene : hkReferencedObject
    {

        public string m_modeller;
        public string m_asset;
        public float m_sceneLength;
        public hkxNode /*pointer struct*/ m_rootNode;
        public List<hkxNodeSelectionSet> m_selectionSets;
        public List<hkxCamera> m_cameras;
        public List<hkxLight> m_lights;
        public List<hkxMesh> m_meshes;
        public List<hkxMaterial> m_materials;
        public List<hkxTextureInplace> m_inplaceTextures;
        public List<hkxTextureFile> m_externalTextures;
        public List<hkxSkinBinding> m_skinBindings;
        public Matrix4x4 m_appliedTransform;

        public override uint Signature => 0x5f673ddd;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {

            base.Read(des, br);
            m_modeller = des.ReadStringPointer(br);
            m_asset = des.ReadStringPointer(br);
            m_sceneLength = br.ReadSingle();
            br.Position += 4;
            m_rootNode = des.ReadClassPointer<hkxNode>(br);
            m_selectionSets = des.ReadClassPointerArray<hkxNodeSelectionSet>(br);
            m_cameras = des.ReadClassPointerArray<hkxCamera>(br);
            m_lights = des.ReadClassPointerArray<hkxLight>(br);
            m_meshes = des.ReadClassPointerArray<hkxMesh>(br);
            m_materials = des.ReadClassPointerArray<hkxMaterial>(br);
            m_inplaceTextures = des.ReadClassPointerArray<hkxTextureInplace>(br);
            m_externalTextures = des.ReadClassPointerArray<hkxTextureFile>(br);
            m_skinBindings = des.ReadClassPointerArray<hkxSkinBinding>(br);
            m_appliedTransform = des.ReadMatrix3(br);

            // throw new NotImplementedException("code generated. check first");
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {

            base.Write(s, bw);
            s.WriteStringPointer(bw, m_modeller);
            s.WriteStringPointer(bw, m_asset);
            bw.WriteSingle(m_sceneLength);
            bw.Position += 4;
            s.WriteClassPointer(bw, m_rootNode);
            s.WriteClassPointerArray<hkxNodeSelectionSet>(bw, m_selectionSets);
            s.WriteClassPointerArray<hkxCamera>(bw, m_cameras);
            s.WriteClassPointerArray<hkxLight>(bw, m_lights);
            s.WriteClassPointerArray<hkxMesh>(bw, m_meshes);
            s.WriteClassPointerArray<hkxMaterial>(bw, m_materials);
            s.WriteClassPointerArray<hkxTextureInplace>(bw, m_inplaceTextures);
            s.WriteClassPointerArray<hkxTextureFile>(bw, m_externalTextures);
            s.WriteClassPointerArray<hkxSkinBinding>(bw, m_skinBindings);
            s.WriteMatrix3(bw, m_appliedTransform);

            // throw new NotImplementedException("code generated. check first");
        }
    }
}

