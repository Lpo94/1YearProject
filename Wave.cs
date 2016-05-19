using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _1YearProject
{
    class Wave
    {
        private int enemyCount;
        private int waveNumber;
        private float spawnTimer = 0;
        private int enemiesSpawned = 0;

        private bool enemyFinish;
        private bool enemySpawn;
        private Level level;
        private Texture2D enemyTexture;
        public List<Enemy> enemies = new List<Enemy>();

        public bool RoundOver
        {
            get { return enemies.Count == 0 && enemiesSpawned == enemyCount; }
        }
        public int RoundNumber
        {
            get { return waveNumber; }
        }
        public bool EnemyFinish
        {
            get { return enemyFinish; }
            set { enemyFinish = value; }
        }
        public List<Enemy> Enemies
        {
            get { return enemies; }
        }

        public Wave(int waveNumber, int enemyCount, Level level, Texture2D enemyTexture)
        {
            this.waveNumber = waveNumber;
            this.enemyCount = enemyCount;
            this.level = level;
            this.enemyTexture = enemyTexture;
        }

        private void AddEnemy()
        {
            Enemy enemy = new Enemy(enemyTexture, level.Waypoints.Peek(), 50, 20, 2.5f);
            enemy.SetWaypoints(level.Waypoints);
            enemies.Add(enemy);
            spawnTimer = 0;

            enemiesSpawned++;
        }

        public void Start()
        {
            enemySpawn = true;
        }

        public void Update(GameTime gameTime)
        {
            if (enemiesSpawned == enemyCount) { enemySpawn = false; }
            if (enemySpawn)
            {
                spawnTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (spawnTimer > 0.5) { AddEnemy(); }
            }

            for ( int i = 0; i < enemies.Count; i++)
            {
                Enemy enemy = enemies[i];
                enemy.Update(gameTime);
                if (enemy.IsDead)
                {
                    if (enemy.CurrentHealth > 0)
                    {
                        enemyFinish = true;
                    }
                    enemies.Remove(enemy);
                    i--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy enemy in enemies) { enemy.Draw(spriteBatch); }
        }
    }
}
