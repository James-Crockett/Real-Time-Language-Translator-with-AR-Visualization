<!-- # Real-Time-Language-Translator-with-AR-Visualization
This project integrates a Transformer-based model for English-to-Tamil translation with Marker-Based Augmented Reality (AR) using the Vuforia SDK. Speech input is captured using Mozilla DeepSpeech, translated into Tamil, and displayed in real-time as AR overlays on recognized image markers. This pipeline demonstrates seamless integration of NLP, speech recognition, and AR for immersive language translation experiences.

Transformer Credits: https://github.com/ajhalthor -->

# Real-Time Language Translator with AR Visualization

## Overview
This project bridges the gap between spoken communication and visual understanding by integrating Neural Machine Translation (NMT) with Augmented Reality (AR). It creates an immersive translation experience where spoken English is instantly converted into Tamil text and overlaid onto the physical world using marker-based tracking.

The system captures audio input, transcribes it, translates it using a Transformer model, and renders the output as a dynamic 3D overlay on specific image targets. This pipeline showcases the seamless convergence of Speech Recognition, Natural Language Processing (NLP), and Computer Vision.

## Key Features
- **Automatic Speech Recognition (ASR):** Utilizes **Mozilla DeepSpeech** to capture and transcribe spoken English with high accuracy in real-time.
- **Neural Machine Translation:** Deploys a custom **Transformer-based model** to translate English text into Tamil. The architecture uses self-attention mechanisms to handle long-range dependencies and ensure grammatical accuracy in the target language.
- **Marker-Based AR:** Leverages the **Vuforia SDK** to detect physical image markers. Once a marker is recognized, the translated Tamil text is projected onto it, aligning digital information with the real-world environment.
- **End-to-End Pipeline:** A unified framework that processes raw audio, generates text inference, and updates the AR display with minimal latency.

## Technical Stack
- **Speech Engine:** Mozilla DeepSpeech
- **Translation Model:** Transformer (PyTorch)
- **AR Platform:** Unity, Vuforia SDK
- **Language:** Python

## Credits
- Transformer model implementation adapted from [ajhalthor](https://github.com/ajhalthor).
- [Mozilla DeepSpeech](https://github.com/mozilla/DeepSpeech)
