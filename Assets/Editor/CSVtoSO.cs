using UnityEditor;
using UnityEngine;
using System.IO;

public class CSVtoSO
{
    private static string characterCSVPath = "/Editor/CSVs/CharacterCSV.csv";
    private static string weaponCSVPath = "/Editor/CSVs/WeaponCSV.csv";

    [MenuItem("Utilities/Generate Characters")]
    public static void GenerateCharacters()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + characterCSVPath);

        foreach (string s in allLines)
        {
            string[] splitData = s.Split(',');

            if (splitData.Length != 5)
            {
                return;
            }

            Character character = ScriptableObject.CreateInstance<Character>();
            character.characterId = int.Parse(splitData[0]);
            character.speed = float.Parse(splitData[1]);
            character.maxHealth = int.Parse(splitData[2]);
            character.characterName = splitData[3];
            character.spritePath = splitData[4];

            AssetDatabase.CreateAsset(character, $"Assets/Resources/ScriptableObjects/Characters/{character.characterName}.asset");
        }

        AssetDatabase.SaveAssets();
    }

    [MenuItem("Utilities/Generate Weapons")]
    public static void GenerateWeapons()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + weaponCSVPath);

        foreach (string s in allLines)
        {
            string[] splitData = s.Split(',');

            if (splitData.Length != 9)
            {
                return;
            }

            Weapon weapon = ScriptableObject.CreateInstance<Weapon>();
            weapon.weaponId = int.Parse(splitData[0]);
            weapon.weaponName = splitData[1];
            weapon.attackPower = int.Parse(splitData[2]);
            weapon.spritePath = splitData[3];
            weapon.weaponType = splitData[4];
            weapon.cooldown = float.Parse(splitData[5]);
            weapon.weaponRange = float.Parse(splitData[6]);
            weapon.ammoCount = int.Parse(splitData[7]);
            weapon.cost = int.Parse(splitData[8]);

            AssetDatabase.CreateAsset(weapon, $"Assets/Resources/ScriptableObjects/Weapons/{weapon.weaponName}.asset");
        }

        AssetDatabase.SaveAssets();
    }
}
