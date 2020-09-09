using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarData
{
    // Data and discriptions taken from http://astronexus.com/hyg/

    /// <summary>
    /// The database primary key from a larger "master database" of stars.
    /// </summary>
    public int StarID;
    public int HIP;
    /// <summary>
    ///  The star's ID in the Henry Draper catalog, if known.
    /// </summary>
    public int HD;
    /// <summary>
    /// The star's ID in the Harvard Revised catalog, which is the same as its number in the Yale Bright Star Catalog.
    /// </summary>
    public int HR;
    /// <summary>
    /// The star's ID in the third edition of the Gliese Catalog of Nearby Stars.
    /// </summary>
    public string Gliese;
    /// <summary>
    /// The Bayer / Flamsteed designation, from the Fifth Edition of the Yale Bright Star Catalog.This is a combination of the two designations. The Flamsteed number, if present, is given first; then a three-letter abbreviation for the Bayer Greek letter; the Bayer superscript number, if present; and finally, the three-letter constellation abbreviation.Thus Alpha Andromedae has the field value "21Alp And", and Kappa1 Sculptoris(no Flamsteed number) has "Kap1Scl".
    /// </summary>
    public string BayerFlamsteed;
    /// <summary>
    /// A common name for the star, such as "Barnard's Star" or "Sirius". I have taken these names primarily from the Hipparcos project's web site, which lists representative names for the 150 brightest stars and many of the 150 closest stars. I have added a few names to this list. Most of the additions are designations from catalogs mostly now forgotten (e.g., Lalande, Groombridge, and Gould ["G."]) except for certain nearby stars which are still best known by these designations.
    /// </summary>
    public string ProperName;
    /// <summary>
    ///  The star's right ascension. for epoch 2000.0. Stars present only in the Gliese Catalog, which uses 1950.0 coordinates, have had these coordinates precessed to 2000.
    /// </summary>
    public float RA;
    /// <summary>
    ///  The star's declination. for epoch 2000.0. Stars present only in the Gliese Catalog, which uses 1950.0 coordinates, have had these coordinates precessed to 2000.
    /// </summary>
    public float Dec;
    /// <summary>
    /// The star's distance in parsecs, the most common unit in astrometry. To convert parsecs to light years, multiply by 3.262. A value of 10000000 indicates missing or dubious (e.g., negative) parallax data in Hipparcos.
    /// </summary>
    public float Distance;
    public float PMRA;
    public float PMDec;
    public float RV;
    /// <summary>
    /// The star's apparent visual magnitude.
    /// </summary>
    public float Mag;
    /// <summary>
    /// The star's absolute visual magnitude (its apparent magnitude from a distance of 10 parsecs).
    /// </summary>
    public float AbsMag;
    /// <summary>
    /// The star's spectral type, if known.
    /// </summary>
    public string Spectrum;
    /// <summary>
    /// The star's color index (blue magnitude - visual magnitude), where known.
    /// </summary>
    public float ColorIndex;
    //The Cartesian coordinates of the star, in a system based on the equatorial coordinates as seen from Earth. +X is in the direction of the vernal equinox (at epoch 2000), +Z towards the north celestial pole, and +Y in the direction of R.A. 6 hours, declination 0 degrees.
    /// <summary>
    /// x position of the star
    /// </summary>
    public float X;
    /// <summary>
    /// y position of the star
    /// </summary>
    public float Y;
    /// <summary>
    /// z position of the star
    /// </summary>
    public float Z;
    //The Cartesian velocity components of the star, in the same coordinate system described immediately above. They are determined from the proper motion and the radial velocity (when known). The velocity unit is parsecs per year; these are small values (around 10-5 to 10-6), but they enormously simplify calculations using parsecs as base units for celestial mapping.
    /// <summary>
    /// x velocity of the star
    /// </summary>
    public float VX;
    /// <summary>
    /// y velocity of the star
    /// </summary>
    public float VY;
    /// <summary>
    /// z velocity of the star
    /// </summary>
    public float VZ;
}
