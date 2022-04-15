﻿namespace ShelterCore.Cryptography;

public interface ICryptography
{
    string Encode(string str);
    string Decode(string str);
}
