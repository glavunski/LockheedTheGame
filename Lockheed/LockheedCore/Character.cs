using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace LockHeedCore
{
   
   public class Character
    {

     
       public string HeadPiece { get; set; }
       public string Legs { get; set; }
       public string Body { get; set; }
       public string Hand { get; set; }
       public int Mana { get; set; }
       public List<Skill> UnlockedSkills { get; set; }
       public List<Tier> UnlockedTiers { get; set; }
       public float X { get; set; }
       public float Y { get; set; }

        public Character()
        {

        }

        public void Die(string deathAnimation)
        { 
        
        
        }
        public void Draw(this Character character, RenderTarget renderer)
        {
            Sprite legs = new Sprite(new Texture(character.Legs));
            legs.Position = new Vector2f(character.X, character.Y + 10);
            renderer.Draw(legs);
            Sprite body = new Sprite(new Texture(character.Body));
            body.Position = new Vector2f(character.X, character.Y + 30);
            renderer.Draw(body);
            Sprite head = new Sprite(new Texture(character.HeadPiece));
            head.Position = new Vector2f(character.X, character.Y+50);
            renderer.Draw(head);
            
            
        }


    }
}
