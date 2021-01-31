using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Logic
{
    public class Game
    {
        public Game()
        {

        }

        public async ValueTask Initialise(IJSRuntime jsRuntime)
        {
            //_canvasTimingInformation = new();
            //_tempSprites = new();
            //_pauser = new(0.Milliseconds(), () => { });
            //// POINTER: You can change the starting Act by using something like:
            //// _currentAct = new TornGhostChaseAct(new AttractAct());

            //// ReSharper disable once HeapView.BoxingAllocation
            //_currentAct = await _mediator.Send(new GetActRequest("AttractAct"));
            //await _gameSoundPlayer.LoadAll(jsRuntime);
            //_initialised = true;
        }
    }
}
