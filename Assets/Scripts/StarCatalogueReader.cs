using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class StarCatalogueReader : MonoBehaviour
{
    public NamedStar namedStarPrefab;
    public Transform center;
    public TextAsset cataloque;

    public ParticleSystem particleSystem;

    Gradient BV_gradient;
    GradientColorKey[] BV_colorKey;
    GradientAlphaKey[] BV_alphaKey;

    List<StarData> StarDataList = new List<StarData>();

    void Start()
    {
        EnitColorGradient();

        string[] data = cataloque.text.Split(new char[] { '\n' });

        //Note: First row is data labels, so skip that one
        for(int i = 1; i < data.Length; i++)
        {
            StarData sd = new StarData();

            var style = NumberStyles.Float;
            var culture = CultureInfo.InvariantCulture;

            string[] row = data[i].Split(new char[] { ',' });
            int.TryParse(row[0], style, culture, out sd.StarID);
            int.TryParse(row[1], out sd.HIP);
            int.TryParse(row[2], out sd.HD);
            int.TryParse(row[3], out sd.HR);
            sd.Gliese = row[4];
            sd.BayerFlamsteed = row[5];
            sd.ProperName = row[6];
            float.TryParse(row[7], out sd.RA);
            float.TryParse(row[8], out sd.Dec);
            float.TryParse(row[9], out sd.Distance);
            //Don't bother with PMRA, PMDec and RV
            float.TryParse(row[13], style, culture, out sd.Mag);
            float.TryParse(row[14], style, culture, out sd.AbsMag);
            sd.Spectrum = row[15];
            float.TryParse(row[16], style, culture, out sd.ColorIndex);
            float.TryParse(row[17], style, culture, out sd.X);
            float.TryParse(row[18], style, culture, out sd.Y);
            float.TryParse(row[19], style, culture, out sd.Z);
            float.TryParse(row[20], style, culture, out sd.VX);
            float.TryParse(row[21], style, culture, out sd.VY);
            float.TryParse(row[22], style, culture, out sd.VZ);

            StarDataList.Add(sd);
            
        }

        for (int i = 0; i < StarDataList.Count; i++)
        {
            Vector3 pos = new Vector3(StarDataList[i].X, StarDataList[i].Y, StarDataList[i].Z) / 1f;
            Color32 color = GetBVColor(StarDataList[i].ColorIndex);
            float size = ExtensionMethods.Remap(StarDataList[i].AbsMag, 17f, -10f, 0.1f, 1f);

            if (string.IsNullOrEmpty(StarDataList[i].ProperName))
            {
                var emitParams = new ParticleSystem.EmitParams();
                emitParams.position = pos;
                emitParams.startColor = color;
                emitParams.startSize = size;

                particleSystem.Emit(emitParams, 1);
            }
            else
            {
                NamedStar star = Instantiate(namedStarPrefab, pos, Quaternion.identity, center);

                star.Init(size, color, StarDataList[i].ProperName);

            }


            
        }

    }

    private void SpawnNamedStar(StarData sd)
    {

    }

    private void EnitColorGradient()
    {
        BV_gradient = new Gradient();

        /* Populate color keys. Color for BV is not liniar. Thus all the keys.
         * This gradient is taken from https://www.esri.com/arcgis-blog/products/mapping/mapping/map-the-stars-with-size-transparency-and-color/
         * Unity gradients can only contain 8 keys
         */
        BV_colorKey = new GradientColorKey[8];
        ColorUtility.TryParseHtmlString("#9bb2ff", out BV_colorKey[0].color);
        ColorUtility.TryParseHtmlString("#c4d2ff", out BV_colorKey[1].color);
        ColorUtility.TryParseHtmlString("#eeefff", out BV_colorKey[2].color);
        ColorUtility.TryParseHtmlString("#fff5ef", out BV_colorKey[3].color);
        ColorUtility.TryParseHtmlString("#ffe6ca", out BV_colorKey[4].color);
        ColorUtility.TryParseHtmlString("#ffdfb8", out BV_colorKey[5].color);
        ColorUtility.TryParseHtmlString("#ddf29c", out BV_colorKey[6].color);
        ColorUtility.TryParseHtmlString("#ff5200", out BV_colorKey[7].color);
        /*
        ColorUtility.TryParseHtmlString("#d3ddff", out BV_colorKey[8].color);
        ColorUtility.TryParseHtmlString("#dae2ff", out BV_colorKey[9].color);
        ColorUtility.TryParseHtmlString("#dfe5ff", out BV_colorKey[10].color);
        ColorUtility.TryParseHtmlString("#e4e9ff", out BV_colorKey[11].color);
        ColorUtility.TryParseHtmlString("#e9ecff", out BV_colorKey[12].color);
        ColorUtility.TryParseHtmlString("#eeefff", out BV_colorKey[13].color);
        ColorUtility.TryParseHtmlString("#f3f2ff", out BV_colorKey[14].color);
        ColorUtility.TryParseHtmlString("#f8f6ff", out BV_colorKey[15].color);
        ColorUtility.TryParseHtmlString("#fef9ff", out BV_colorKey[16].color);
        ColorUtility.TryParseHtmlString("#fff9fb", out BV_colorKey[17].color);
        ColorUtility.TryParseHtmlString("#fff7f5", out BV_colorKey[18].color);
        ColorUtility.TryParseHtmlString("#fff5ef", out BV_colorKey[19].color);
        ColorUtility.TryParseHtmlString("#fff3ea", out BV_colorKey[20].color);
        ColorUtility.TryParseHtmlString("#fff1e5", out BV_colorKey[21].color);
        ColorUtility.TryParseHtmlString("#ffefe0", out BV_colorKey[22].color);
        ColorUtility.TryParseHtmlString("#ffeddb", out BV_colorKey[23].color);
        ColorUtility.TryParseHtmlString("#ffebd6", out BV_colorKey[24].color);
        ColorUtility.TryParseHtmlString("#ffe9d2", out BV_colorKey[25].color);
        ColorUtility.TryParseHtmlString("#ffe8ce", out BV_colorKey[26].color);
        ColorUtility.TryParseHtmlString("#ffe6ca", out BV_colorKey[27].color);
        ColorUtility.TryParseHtmlString("#ffe5c6", out BV_colorKey[28].color);
        ColorUtility.TryParseHtmlString("#ffe3c3", out BV_colorKey[29].color);
        ColorUtility.TryParseHtmlString("#ffe2bf", out BV_colorKey[30].color);
        ColorUtility.TryParseHtmlString("#ffe0bb", out BV_colorKey[31].color);
        ColorUtility.TryParseHtmlString("#ffdfb8", out BV_colorKey[32].color);
        ColorUtility.TryParseHtmlString("#ffddb4", out BV_colorKey[33].color);
        ColorUtility.TryParseHtmlString("#ffdbb0", out BV_colorKey[34].color);
        ColorUtility.TryParseHtmlString("#ffdaad", out BV_colorKey[35].color);
        ColorUtility.TryParseHtmlString("#ffd8a9", out BV_colorKey[36].color);
        ColorUtility.TryParseHtmlString("#ffd6a5", out BV_colorKey[37].color);
        ColorUtility.TryParseHtmlString("#ffd5a1", out BV_colorKey[38].color);
        ColorUtility.TryParseHtmlString("#ddf29c", out BV_colorKey[39].color);
        ColorUtility.TryParseHtmlString("#ffd096", out BV_colorKey[40].color);
        ColorUtility.TryParseHtmlString("#ffcc8f", out BV_colorKey[41].color);
        ColorUtility.TryParseHtmlString("#ffc885", out BV_colorKey[42].color);
        ColorUtility.TryParseHtmlString("#ffc178", out BV_colorKey[43].color);
        ColorUtility.TryParseHtmlString("#ffb765", out BV_colorKey[44].color);
        ColorUtility.TryParseHtmlString("#ffa94b", out BV_colorKey[45].color);
        ColorUtility.TryParseHtmlString("#ff9523", out BV_colorKey[46].color);
        ColorUtility.TryParseHtmlString("#ff7b00", out BV_colorKey[47].color);
        ColorUtility.TryParseHtmlString("#ff5200", out BV_colorKey[48].color);
        */

        for (int i = 0; i < BV_colorKey.Length; i++)
        {
            BV_colorKey[i].time = (float)i/(float)BV_colorKey.Length;
        }

        BV_alphaKey = new GradientAlphaKey[2];
        BV_alphaKey[0].alpha = 1f;
        BV_alphaKey[0].time = 0f;
        BV_alphaKey[1].alpha = 1f;
        BV_alphaKey[1].time = 1f;

        BV_gradient.SetKeys(BV_colorKey, BV_alphaKey);
    }

    private Color32 GetBVColor(float colorIndex)
    {
        float mappedColorIndex = ExtensionMethods.Remap(colorIndex, -0.40f, 2f, 0f, 1f); 

        return BV_gradient.Evaluate(mappedColorIndex);
    }
}
