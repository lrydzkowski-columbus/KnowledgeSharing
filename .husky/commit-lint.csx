using System.Text.RegularExpressions;

if (Args.Count == 0)
{
    return 1;
}

string commitMsg = File.ReadAllText(Args[0]);
string verificationPattern = @"^(build|chore|ci|docs|feat|fix|perf|refactor|revert|style|test|init|version){1}(\([\w\-\.]+\))?(!)?: ([\w #])+([\s\S]*)|^(?<merge>(Merged|Merge) \w+)";
Regex verificationRegex = new Regex(verificationPattern);

if (!verificationRegex.Match(commitMsg).Success)
{
    Console.WriteLine();
    Console.WriteLine("Your commit message is incorrectly formatted!");
    Console.WriteLine("You should follow conventional commits specification:");
    Console.WriteLine("https://www.conventionalcommits.org/en/v1.0.0/");
    Console.WriteLine();
    return 1;
}

return 0;