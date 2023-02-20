namespace PokemonAPI.Models;

public class Level
{
    private const int MaxLevel = 100;
    private readonly int[] _experiencePerLevel;

    public Level()
    {
        _experiencePerLevel = new int[MaxLevel];
        _experiencePerLevel[0] = 100;
        for (int i = 1; i < MaxLevel; i++)
        {
            _experiencePerLevel[i] = (int)(_experiencePerLevel[i - 1] * 1.5);
        }
    }

    public int GetCurrentLevel(int currentExperience)
    {
        for (int i = 0; i < MaxLevel; i++)
        {
            if (currentExperience < _experiencePerLevel[i])
            {
                return i + 1;
            }
        }
        return MaxLevel;
    }

    public int GetExperienceToNextLevel(int currentExperience)
    {
        int currentLevel = GetCurrentLevel(currentExperience);
        if (currentLevel < MaxLevel)
        {
            return _experiencePerLevel[currentLevel] - currentExperience;
        }
        return 0;
    }
}