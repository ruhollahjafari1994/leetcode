public class Program
{
    public static void Main(string[] args)
    {
        // Create a Solution instance
        Solution solution = new Solution();

        // Example 1
        IList<string> dictionary1 = new List<string> { "cat", "bat", "rat" };
        string sentence1 = "the cattle was rattled by the battery";
        Console.WriteLine("Output 1: " + solution.ReplaceWords(dictionary1, sentence1));

        // Example 2
        IList<string> dictionary2 = new List<string> { "a", "b", "c" };
        string sentence2 = "aadsfasf absbs bbab cadsfafs";
        Console.WriteLine("Output 2: " + solution.ReplaceWords(dictionary2, sentence2));

        // Add more test cases if needed
    }
}


public class Solution
    {
        public string ReplaceWords(IList<string> dictionary, string sentence)
        {
            // Step 1: Build the Trie from the dictionary
            TrieNode root = new TrieNode();
            foreach (var word in dictionary)
            {
                InsertWord(root, word);
            }

            // Step 2: Process each word in the sentence
            var words = sentence.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = FindRoot(root, words[i]);
            }

            // Step 3: Join the words to form the final sentence
            return string.Join(" ", words);
        }

        private void InsertWord(TrieNode root, string word)
        {
            var node = root;
            foreach (var ch in word)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    node.Children[ch] = new TrieNode();
                }
                node = node.Children[ch];
            }
            node.IsWord = true;
        }

        private string FindRoot(TrieNode root, string word)
        {
            var node = root;
            var prefix = new System.Text.StringBuilder();

            foreach (var ch in word)
            {
                if (!node.Children.ContainsKey(ch) || node.IsWord)
                {
                    break;
                }
                prefix.Append(ch);
                node = node.Children[ch];
            }

            return node.IsWord ? prefix.ToString() : word;
        }
    }

    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        public bool IsWord = false;
    }
