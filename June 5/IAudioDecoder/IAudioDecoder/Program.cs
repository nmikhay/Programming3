using System;

public interface IAudioDecoder
{
    void Decode();
}

public class Mp3Decoder : IAudioDecoder
{
    public void Decode()
    {
        Console.WriteLine("Decoding MP3 file...");
    }
}

public class WavDecoder : IAudioDecoder
{
    public void Decode()
    {
        Console.WriteLine("Decoding WAV file...");
    }
}

public class FlacDecoder : IAudioDecoder
{
    public void Decode()
    {
        Console.WriteLine("Decoding FLAC file...");
    }
}

public class MusicPlayer
{
    private IAudioDecoder _audioDecoder;

    public MusicPlayer(IAudioDecoder audioDecoder)
    {
        _audioDecoder = audioDecoder;
    }

    public void Play()
    {
        _audioDecoder.Decode();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var mp3Player = new MusicPlayer(new Mp3Decoder());
        mp3Player.Play();

        var wavPlayer = new MusicPlayer(new WavDecoder());
        wavPlayer.Play();

        var flacPlayer = new MusicPlayer(new FlacDecoder());
        flacPlayer.Play();
    }
}

